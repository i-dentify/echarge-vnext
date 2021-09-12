use async_graphql::{EmptySubscription, Schema};

use echarge_car_lib::persistence::write::get_client as get_eventstore_client;
use echarge_car_lib::persistence::read::get_client as get_mongodb_client;

use crate::graphql::mutation::Mutation;
use crate::graphql::query::Query;

pub(crate) mod inputs;
pub(crate) mod models;
pub(crate) mod query;
pub(crate) mod mutation;
pub(crate) mod events;

pub type AppSchema = Schema<Query, Mutation, EmptySubscription>;

pub async fn create_schema() -> Schema<Query, Mutation, EmptySubscription> {
    let eventstore_client = get_eventstore_client().await;
    let mongodb_client = get_mongodb_client().await;
    Schema::build(Query, Mutation, EmptySubscription)
        .data(eventstore_client)
        .data(mongodb_client)
        .finish()
}