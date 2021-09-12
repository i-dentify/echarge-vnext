use std::env;

use futures::StreamExt;
use mongodb::{Client, Collection};
use mongodb::bson::{doc, to_bson};
use mongodb::error::Error;
use uuid::Uuid;

use crate::persistence::read::models::Car;

#[derive(Clone)]
pub struct CarRepository {
    collection: Collection<Car>,
}

impl CarRepository {
    pub fn new(client: &Client) -> CarRepository {
        let database_name = env::var("MONGODB_DATABASE_NAME").expect("MONGODB_DATABASE_NAME not set!");
        let db = client.database(database_name.as_str());
        let collection = db.collection::<Car>("car");
        CarRepository { collection }
    }

    pub async fn get(&self) -> Result<Vec<Car>, Error> {
        let mut cursor = self.collection.find(None, None).await?;
        let mut items: Vec<Car> = Vec::new();

        while let Some(car) = cursor.next().await {
            items.push(car?);
        }

        Ok(items)
    }

    pub async fn add(&self, car: &Car) {
        self.collection.insert_one(car, None).await.unwrap();
    }

    pub async fn update(&self, car: &Car) {
        self.collection.update_one(doc! {
            "_id": car.id.to_string().as_str()
        }, doc! {
            "$set": to_bson(car).unwrap()
        }, None).await.unwrap();
    }

    pub async fn delete(&self, id: Uuid) {
        self.collection.delete_one(doc! {
            "_id": id.to_string().as_str()
        }, None).await.unwrap();
    }
}
