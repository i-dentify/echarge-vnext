use uuid::Uuid;

use echarge_car_lib::events::{CarAdded, CarEdited};

use crate::graphql::inputs::{CreateCarInput, EditCarInput};

impl From<CreateCarInput> for CarAdded {
    fn from(source: CreateCarInput) -> Self {
        CarAdded {
            id: Uuid::new_v4(),
            name: source.car.name,
            battery_capacity: source.car.battery_capacity,
            owner: "".to_owned()
        }
    }
}

impl From<EditCarInput> for CarEdited {
    fn from(source: EditCarInput) -> Self {
        CarEdited {
            id: Uuid::parse_str(source.id.as_str()).unwrap(),
            name: source.car.name,
            battery_capacity: source.car.battery_capacity
        }
    }
}
