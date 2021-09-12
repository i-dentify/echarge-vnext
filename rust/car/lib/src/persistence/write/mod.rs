use std::env;

use eventstore::Client;

pub async fn get_client() -> Client {
    let connection_string = env::var("EVENTSTORE_CONNECTION_STRING").expect("EVENTSTORE_CONNECTION_STRING not set!");
    let settings = connection_string.parse().expect("Unable to parse write connection string");
    Client::create(settings).await.unwrap()
}