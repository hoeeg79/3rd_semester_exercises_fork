
### Guided solutions can be found here: https://github.com/uldahlalex/dotnetwebapi check Controllers/SolutionsController.cs

## Important: .NET 8 uses another default layout, so i recommend cloning this repo with version 8 and controllers:

```bash
git clone https://github.com/uldahlalex/dotnetwebapi
```

### Create and Run a Web API Using the .NET CLI 

- **Task:** Use the .NET CLI to establish a new Web API. Run the program.
- **Success Criteria:** Send an HTTP request and receive a response. 

**Objective:** You must know how to set up a basic Web API with a single endpoint.

---

### Swagger / OpenAPI



- **Task:** When the program is running, try and open the Swagger / OpenAPI page, and request an endpoint.
If Swagger is not enabled in Program.cs, see this guide: 
https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=visual-studio

- **Success Criteria:** Getting an HTTP response from the default startup application through Swagger.

**Objective:** Learn to navigate to Swagger and send basic requests.

---

### New Controller



- **Task:** Create a new Controller class with an endpoint.
- **Success Criteria:** You should be able to discover the endpoint in Swagger and send request and get a response.

**Objective:** Learn to create new Controllers / groupings of endpoints.

Bonus: Why do you think .NET Web API is capable of "automatically" adding your Controller class to it's valid routes?

---

### GET entity/{id}

**Task:** Make a GET endpoint that can read a route segment (for instance use 

```C#
[FromRoute] int id
```
in the method parameter
). Return the id to the requester.

**Success criteria:** When inserting id 42 in Swagger as route segment, you should be able to get the id number response


**Learning objective:** You must know how to read/get data from a route segment which the client passes

---

### GET entity?someKey=someValue

**Task:** Make a GET endpoint that can read a query parameter using:

```c#
[FromQuery]string someValue
```
Return the value to the client.

**Success criteria:** When inserting hello world as a query parameter, you should get that value returned.

**Learning objective:** You must know how to read/get data from a query parameter which the client passes

---

### GET with header attached

#### Correction: Here I meant SET a header with query params, not read

**Task:** Make a GET endpoint that can read a header using:

```c#
[FromHeader]string someValue
```
Return the value to the client.
(Pick an obscure random name to make sure it is a value you manually left there in Swagger/other HTTP client)

**Success criteria:** When inserting some header value, you should get the value back.

**Learning objective:** You must know how to read/get data from an HTTP header which the client passes

---

### Setting some custom header

#### Note: You can both read/write the headers using this class:

**Task:** Use the HttpContext class to set some HTTP response header in some endpoint.

**Success criteria:** Send a request to that endpoint with Postman and inspect the response headers. The value should be present.

**Learning objective:** You must know how to use the HttpContext to modify http responses.

---

### Response JSON

**Task:** Return some JSON object to the client in the body(payload) by returning a C# object.

**Success criteria**: If the serialization is successful, the client should get the object values as JSON.

**Learning objective**: You must know how to set the HTTP response body.

---

### Response status code

**Task:** Manually set the response status code. You can do this using HttpContext. Pick an obscure status code like 418, so you don't accidentally pick the same code as the default.

**Success criteria**: You should see the expected code client side.

**Learning objective**: You must know how to indicate the response status to the client by using status codes.

---


