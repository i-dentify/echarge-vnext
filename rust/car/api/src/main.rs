use std::env;

use actix_web::{App, HttpServer};
use actix_web::web::Data;
use dotenv::dotenv;

use echarge_car_api::configure_service;
use echarge_car_api::graphql::create_schema;

#[actix_web::main]
async fn main() -> std::io::Result<()> {
    dotenv().ok();

    let address = env::var("BIND_TO").expect("BIND_TO not set!");
    let schema = create_schema().await;

    HttpServer::new(move || App::new()
        .configure(configure_service)
        .app_data(Data::new(schema.clone())))
        .bind(&address)?
        .run()
        .await
}