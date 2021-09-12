use mongodb::Client;
use eventstore::{Client as EventStoreClient, SubEvent};
use echarge_car_lib::events::{CarAdded, CarEdited, CarDeleted};
use echarge_car_lib::persistence::read::models::Car;
use std::error::Error;
use echarge_car_lib::persistence::read::repository::CarRepository;

type Result<A> = std::result::Result<A, Box<dyn Error>>;

pub async fn subscribe_to_stream(event_store_client: &EventStoreClient, mongodb_client: &Client) -> Result<()> {
    let (mut read, mut write) = event_store_client
        .connect_persistent_subscription("car", "car", &Default::default())
        .await?;

    while let Some(event) = read.try_next().await? {
        if let SubEvent::EventAppeared(event) = event {
            let original_event = event.get_original_event();

            match original_event.event_type.to_lowercase().as_str() {
                "add" => {
                    let repository = CarRepository::new(mongodb_client);
                    let car_added = original_event.as_json::<CarAdded>()?;
                    repository.add(&Car::from(car_added)).await;
                    println!("{:?}", original_event);
                }
                "edit" => {
                    let repository = CarRepository::new(mongodb_client);
                    let car_modified = original_event.as_json::<CarEdited>()?;
                    repository.update(&Car::from(car_modified)).await;
                    println!("{:?}", original_event);
                }
                "delete" => {
                    let repository = CarRepository::new(mongodb_client);
                    let car_deleted = original_event.as_json::<CarDeleted>()?;
                    repository.delete(car_deleted.id).await;
                    println!("{:?}", original_event);
                }
                _ => ()
            }

            write.ack_event(event).await.unwrap();
        }
    }

    Ok(())
}