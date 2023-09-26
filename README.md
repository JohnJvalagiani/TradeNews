
# TradeNews

# User Story: News Aggregation and Web API

# Trading News System

## User Stories

### 1. Consume Trading News

**Description:** The system automatically fetches trading news every 1 hour from the [polygon.io](https://polygon.io/) provider.

### 2. Enrich and Store News Data

**Description:** For each news item retrieved:
- a. The system enriches the data with additional information, such as a ticker chart.
- b. The enriched news data is then saved in a storage solution for future retrieval.

### 3. Create Web API for Clients

**Description:** The system provides a Web API accessible to any client. This API includes the following functionalities:

### 4. Get All News

**Description:** Authorized users can retrieve all trading news through this API.

### 5. Get News from Today – {n} Days

**Description:** Authorized users can retrieve trading news from today and up to a specified number of days in the past.

### 6. Get News by Instrument Name with News Limit

**Description:** Authorized users can retrieve trading news for a specific instrument name, including an optional news limit (default limit should be 10).

### 7. Get News that Contains {Text}

**Description:** Authorized users can search for trading news that contains specific text.

### 8. User Subscription

**Description:** Authorized users have the ability to subscribe to receive notifications or updates related to trading news.

### 9. Public Endpoint: Get Latest News

**Description:** A public endpoint allows users to retrieve the latest news for conversion tools, including the top latest news for five different instruments.

# Components

### Server

The Server component acts as the entry point for incoming requests and serves as the representation layer of the application. It also hosts background services responsible for various tasks.

**Responsibilities of the Server component:**
- Receives and handles incoming HTTP requests.
- Hosts background services (e.g., scheduled tasks, notifications).
- Acts as the interface between clients and the application.

### Application

The Application component houses the core business logic, data persistence, mapping, and services required to process and manipulate data. It serves as the backbone of the system's functionality.

**Responsibilities of the Application component:**
- Implements the core business logic of the application.
- Manages data persistence (e.g., database interactions).
- Performs data mapping and transformation.
- Provides services for retrieving and filtering data.

