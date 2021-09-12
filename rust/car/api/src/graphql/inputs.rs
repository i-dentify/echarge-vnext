use std::num::NonZeroU16;

use async_graphql::{InputObject, ID};

#[derive(InputObject)]
pub struct CreateCarInput {
    pub car: CarInput
}

#[derive(InputObject)]
pub struct EditCarInput {
    pub id: ID,
    pub car: CarInput
}

#[derive(InputObject)]
pub struct CarInput {
    pub name: String,
    pub battery_capacity: NonZeroU16,
}
