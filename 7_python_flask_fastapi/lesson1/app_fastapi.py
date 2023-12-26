import logging
import databases
import sqlalchemy
from fastapi import FastAPI
from typing import Optional, List
from pydantic import BaseModel, Field
from datetime import datetime

logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

DATABASE_URL = "sqlite:///mydatabase.db"
database = databases.Database(DATABASE_URL)
metadata = sqlalchemy.MetaData()

users = sqlalchemy.Table(
    "users",
    metadata,
    sqlalchemy.Column("id", sqlalchemy.Integer, primary_key=True),
    sqlalchemy.Column("first_name", sqlalchemy.String(32)),
    sqlalchemy.Column("last_name", sqlalchemy.String(32)),
    sqlalchemy.Column("email", sqlalchemy.String(128)),
    sqlalchemy.Column("password", sqlalchemy.String(128)),
)

products = sqlalchemy.Table(
    "products",
    metadata,
    sqlalchemy.Column("id", sqlalchemy.Integer, primary_key=True),
    sqlalchemy.Column("name", sqlalchemy.String(64)),
    sqlalchemy.Column("description", sqlalchemy.String(256)),
    sqlalchemy.Column("price", sqlalchemy.Float),
)

orders = sqlalchemy.Table(
    "orders",
    metadata,
    sqlalchemy.Column("id", sqlalchemy.Integer, primary_key=True),
    sqlalchemy.Column("user_id", sqlalchemy.ForeignKey("users.id")),
    sqlalchemy.Column("product_id", sqlalchemy.ForeignKey("products.id")),
    sqlalchemy.Column("order_date", sqlalchemy.DateTime),
    sqlalchemy.Column("order_status", sqlalchemy.String(32)),
)

engine = sqlalchemy.create_engine(DATABASE_URL)
metadata.create_all(engine)

app = FastAPI()

class UserIn(BaseModel):
    first_name: str = Field(max_length=32)
    last_name: str = Field(max_length=32)
    email: str = Field(max_length=128)
    password: str = Field(max_length=128)

class User(BaseModel):
    id: int
    first_name: str = Field(max_length=32)
    last_name: str = Field(max_length=32)
    email: str = Field(max_length=128)

class ProductIn(BaseModel):
    name: str = Field(max_length=64)
    description: str = Field(max_length=256)
    price: float

class Product(BaseModel):
    id: int
    name: str = Field(max_length=64)
    description: str = Field(max_length=256)
    price: float

class orderIn(BaseModel):
    user_id: int
    product_id: int
    order_date: Optional[datetime] = None
    order_status: Optional[str] = None

class order(BaseModel):
    id: int
    user_id: int
    product_id: int
    order_date: Optional[datetime] = None
    order_status: Optional[str] = None

@app.post("/users/", response_model=User)
async def create_user(user: UserIn):
    query = users.insert().values(
        first_name=user.first_name,
        last_name=user.last_name,
        email=user.email,
        password=user.password,
    )
    last_record_id = await database.execute(query)
    return {**user.dict(), "id": last_record_id}

@app.get("/users/", response_model=List[User])
async def read_users():
    query = users.select()
    return await database.fetch_all(query)

@app.get("/users/{user_id}", response_model=User)
async def read_user(user_id: int):
    query = users.select().where(users.c.id == user_id)
    return await database.fetch_one(query)

@app.put("/users/{user_id}", response_model=User)
async def update_user(user_id: int, new_user: UserIn):
    query = (
        users.update()
        .where(users.c.id == user_id)
        .values(
            first_name=new_user.first_name,
            last_name=new_user.last_name,
            email=new_user.email,
            password=new_user.password,
        )
    )
    await database.execute(query)
    return {**new_user.dict(), "id": user_id}

@app.delete("/users/{user_id}")
async def delete_user(user_id: int):
    query = users.delete().where(users.c.id == user_id)
    await database.execute(query)
    return {"message": "User deleted"}

@app.post("/products/", response_model=Product)
async def create_product(product: ProductIn):
    query = products.insert().values(
        name=product.name,
        description=product.description,
        price=product.price,
    )
    last_record_id = await database.execute(query)
    return {**product.dict(), "id": last_record_id}

@app.get("/products/", response_model=List[Product])
async def read_products():
    query = products.select()
    return await database.fetch_all(query)

@app.get("/products/{product_id}", response_model=Product)
async def read_product(product_id: int):
    query = products.select().where(products.c.id == product_id)
    return await database.fetch_one(query)

@app.put("/products/{product_id}", response_model=Product)
async def update_product(product_id: int, new_product: ProductIn):
    query = (
        products.update()
        .where(products.c.id == product_id)
        .values(
            name=new_product.name,
            description=new_product.description,
            price=new_product.price,
        )
    )
    await database.execute(query)
    return {**new_product.dict(), "id": product_id}

@app.delete("/products/{product_id}")
async def delete_product(product_id: int):
    query = products.delete().where(products.c.id == product_id)
    await database.execute(query)
    return {"message": "Product deleted"}

@app.post("/orders/", response_model=order)
async def create_order(order: orderIn):
    query = orders.insert().values(
        product_id=order.product_id,
        user_id=order.user_id,
        order_date=order.order_date,
        order_status=order.order_status,
    )
    last_record_id = await database.execute(query)
    return {**order.dict(), "id": last_record_id}

@app.get("/orders/", response_model=List[order])
async def read_orders():
    query = orders.select()
    return await database.fetch_all(query)

@app.get("/orders/{order_id}", response_model=order)
async def read_order(order_id: int):
    query = orders.select().where(orders.c.id == order_id)
    return await database.fetch_one(query)

@app.put("/orders/{order_id}", response_model=order)
async def update_order(order_id: int, new_order: orderIn):
    query = (
        orders.update()
        .where(orders.c.id == order_id)
        .values(
            product_id=new_order.product_id,
            user_id=new_order.user_id,
            order_date=new_order.order_date,
            order_status=new_order.order_status,
        )
    )
    await database.execute(query)
    return {**new_order.dict(), "id": order_id}

@app.delete("/orders/{order_id}")
async def delete_order(order_id: int):
    query = orders.delete().where(orders.c.id == order_id)
    await database.execute(query)
    return {"message": "order deleted"}


@app.on_event("startup")
async def startup():
    await database.connect()

@app.on_event("shutdown")
async def shutdown():
    await database.disconnect()
