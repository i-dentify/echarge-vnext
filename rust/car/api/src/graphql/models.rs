use std::num::NonZeroU16;

use async_graphql::{ID, Object};
use serde::{Deserialize, Serialize};

#[derive(Serialize, Deserialize)]
pub struct Car {
    pub id: ID,
    pub name: String,
    pub battery_capacity: NonZeroU16,
}

#[Object]
impl Car {
    async fn id(&self) -> &ID {
        &self.id
    }
    async fn name(&self) -> &String {
        &self.name
    }
    async fn battery_capacity(&self) -> &NonZeroU16 {
        &self.battery_capacity
    }
}
