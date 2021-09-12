use async_graphql::{Context, Error, ID, Object};
use eventstore::{Client, EventData};
use uuid::Uuid;

use echarge_car_lib::events::{CarAdded, CarDeleted, CarEdited};

use crate::graphql::inputs::{CreateCarInput, EditCarInput};
use crate::graphql::models::Car;

pub struct Mutation;

#[Object]
impl Mutation {
    async fn add_car(&self, ctx: &Context<'_>, input: CreateCarInput) -> Result<Car, Error> {
        let client = ctx.data::<Client>().unwrap();
        let mut event = CarAdded::from(input);
        event.owner = "John Doe".to_owned();
        let json = EventData::json("add", &event)?;
        let _ = client
            .append_to_stream("car", &Default::default(), json)
            .await?;
        Ok(Car {
            id: ID::from(event.id),
            name: event.name,
            battery_capacity: event.battery_capacity
        })
    }

    async fn edit_car(&self, ctx: &Context<'_>, input: EditCarInput) -> Result<Car, Error> {
        let client = ctx.data::<Client>().unwrap();
        let event = CarEdited::from(input);
        let json = EventData::json("edit", &event)?;
        let _ = client
            .append_to_stream("car", &Default::default(), json)
            .await?;
        Ok(Car {
            id: ID::from(event.id),
            name: event.name,
            battery_capacity: event.battery_capacity,
        })
    }

    async fn delete_car(&self, ctx: &Context<'_>, id: ID) -> Result<ID, Error> {
        let client = ctx.data::<Client>().unwrap();
        let event = CarDeleted {
            id: Uuid::parse_str(id.as_str())?
        };
        let json = EventData::json("delete", &event)?;
        let _ = client
            .append_to_stream("car", &Default::default(), json)
            .await?;
        Ok(id)
    }
}
