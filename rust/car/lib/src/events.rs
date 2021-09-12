use std::num::NonZeroU16;

use serde::{Deserialize, Serialize};
use uuid::Uuid;

#[derive(Serialize, Deserialize, Debug)]
pub struct CarAdded {
    pub id: Uuid,
    pub name: String,
    pub battery_capacity: NonZeroU16,
    pub owner: String
}

#[derive(Serialize, Deserialize, Debug)]
pub struct CarEdited {
    pub id: Uuid,
    pub name: String,
    pub battery_capacity: NonZeroU16
}

#[derive(Serialize, Deserialize, Debug)]
pub struct CarDeleted {
    pub id: Uuid
}