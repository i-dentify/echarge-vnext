use std::num::NonZeroU16;

use async_graphql::{Context, ID, Object};
use mongodb::Client;

use echarge_car_lib::persistence::read::repository::CarRepository;

use crate::graphql::models::Car;

pub struct Query;

#[Object]
impl Query {
    async fn get_cars(&self, ctx: &Context<'_>) -> Vec<Car> {
        let client = ctx.data::<Client>().unwrap();
        let repository = CarRepository::new(client);
        let items = repository.get().await.unwrap();
        items.iter().map(|item| Car {
            id: ID(item.id.to_string()),
            name: item.name.to_string(),
            battery_capacity: NonZeroU16::new(item.battery_capacity as u16).unwrap(),
        }).collect()
    }
}
