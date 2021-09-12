use serde::{Deserialize, Serialize};
use uuid::Uuid;
use crate::events::{CarAdded, CarEdited};

#[derive(Clone, Serialize, Deserialize)]
pub struct Car {
    #[serde(rename = "_id")]
    pub id: Uuid,
    pub name: String,
    pub battery_capacity: i16,
}

impl From<CarAdded> for Car {
    fn from(source: CarAdded) -> Self {
        Car {
            id: source.id,
            name: source.name,
            battery_capacity: source.battery_capacity.get() as i16,
        }
    }
}

impl From<CarEdited> for Car {
    fn from(source: CarEdited) -> Self {
        Car {
            id: source.id,
            name: source.name,
            battery_capacity: source.battery_capacity.get() as i16,
        }
    }
}
