use std::env;

use mongodb::Client;
use mongodb::options::ClientOptions;

pub mod models;
pub mod repository;

pub async fn get_client() -> Client {
    let connection_string = env::var("MONGODB_CONNECTION_STRING").expect("MONGODB_CONNECTION_STRING not set!");
    let options = ClientOptions::parse(connection_string).await.expect("Unable to parse read connection string");
    Client::with_options(options).unwrap()
}
