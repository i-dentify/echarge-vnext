use dotenv::dotenv;

use echarge_car_lib::persistence::read::get_client as get_mongodb_client;
use echarge_car_lib::persistence::write::get_client as get_eventstore_client;
use echarge_car_worker::subscribe_to_stream;

#[tokio::main]
async fn main() -> Result<(), Box<dyn std::error::Error>> {
    dotenv().ok();

    let eventstore_client = get_eventstore_client().await;
    let mongodb_client = get_mongodb_client().await;
    subscribe_to_stream(&eventstore_client, &mongodb_client).await?;

    Ok(())
}
