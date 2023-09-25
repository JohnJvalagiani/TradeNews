
# TradeNews

# User Story: News Aggregation and Web API

## Acceptance Criteria

1. **Consume Trading News:**

   - The system should automatically fetch trading news from any available provider (e.g., https://polygon.io/) every 1 hour.
   - For each news item, enrich the data with additional information, such as a ticker chart.
   - Save the enriched news data in a storage solution for future retrieval.

2. **Web API for Clients:**

   - Create a Web API that any client can access.
   - Implement authorization to secure the API endpoints.

3. **Get All News:**

   - Authorized users should be able to retrieve all trading news.

4. **Get News from Today – {n} Days:**

   - Authorized users should be able to retrieve trading news from today and up to a specified number of days in the past.

5. **Get News by Instrument Name with News Limit:**

   - Authorized users should be able to retrieve trading news for a specific instrument name, including an optional news limit (default limit should be 10).

6. **Get News that Contains {Text}:**

   - Authorized users should be able to search for trading news that contains specific text.

7. **User Subscription:**

   - Authorized users should have the ability to subscribe to receive notifications or updates related to trading news.


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

