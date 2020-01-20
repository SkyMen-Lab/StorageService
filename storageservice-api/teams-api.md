# Teams API

{% api-method method="get" host="https://api.cakes.com" path="/api/team" %}
{% api-method-summary %}
Get Top 10 teams
{% endapi-method-summary %}

{% api-method-description %}
This endpoint allows you to get free cakes.
{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-headers %}
{% api-method-parameter name="Authentication" type="string" required=false %}
Authentication token to track down who is emptying our stocks.
{% endapi-method-parameter %}
{% endapi-method-headers %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=200 %}
{% api-method-response-example-description %}
List successfully retrieved.
{% endapi-method-response-example-description %}

```scheme
[
  {
    "id": 4,
    "code": "009JY",
    "name": "Rugby School",
    "rank": 1,
    "winningRate": 0.0,
    "configId": 4,
    "config": {
      "id": 4,
      "routerIpAddress": "95.130.97.134",
      "routerPort": 2020,
      "connectionType": 0
    },
    "gamesWon": [
      
    ],
    "teamGameSummaries": null
  },
  {
    "id": 5,
    "code": "703SF",
    "name": "Beford School",
    "rank": 2,
    "winningRate": 0.0,
    "configId": 5,
    "config": {
      "id": 5,
      "routerIpAddress": "95.130.97.100",
      "routerPort": 2020,
      "connectionType": 0
    },
    "gamesWon": [
      
    ],
    "teamGameSummaries": null
  },
  {
    "id": 6,
    "code": "866OT",
    "name": "Bedford Girls School",
    "rank": 3,
    "winningRate": 0.0,
    "configId": 6,
    "config": {
      "id": 6,
      "routerIpAddress": "95.130.97.100",
      "routerPort": 3030,
      "connectionType": 0
    },
    "gamesWon": [
      
    ],
    "teamGameSummaries": null
  }
]
```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}

{% api-method method="post" host="" path="/api/team/create" %}
{% api-method-summary %}
Create a team
{% endapi-method-summary %}

{% api-method-description %}

{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-body-parameters %}
{% api-method-parameter name="Name" type="string" required=true %}
Name of the team
{% endapi-method-parameter %}

{% api-method-parameter name="Config" type="object" required=true %}
Config object for connection to Router
{% endapi-method-parameter %}

{% api-method-parameter name="RouterIpAdress" type="string" required=true %}
Config param for IP
{% endapi-method-parameter %}

{% api-method-parameter name="RouterPort" type="integer" required=true %}
Config param for PORT
{% endapi-method-parameter %}

{% api-method-parameter name="ConnectionType" type="integer" required=false %}
0 \(UDP\), 1 \(TCP\)
{% endapi-method-parameter %}
{% endapi-method-body-parameters %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=201 %}
{% api-method-response-example-description %}
Return fully created object with unique code and other properties
{% endapi-method-response-example-description %}

```scheme
{
    "id": 6,
    "code": "866OT",
    "name": "Bedford Girls School",
    "rank": 3,
    "winningRate": 0.0,
    "configId": 6,
    "config": {
        "id": 6,
        "routerIpAddress": "95.130.97.100",
        "routerPort": 3030,
        "connectionType": 0
    },
    "gamesWon": null,
    "teamGameSummaries": null
}
```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=409 %}
{% api-method-response-example-description %}
If name is already used
{% endapi-method-response-example-description %}

```scheme
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.8",
    "title": "Conflict",
    "status": 409,
    "traceId": "|eb75d8e9-4db9ed912e822cbe."
}
```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}

#### Example of POST body request:

```scheme
{
    "Name": "Bedford Girls School",
    "Config": {
        "RouterIpAddress": "95.130.97.100",
        "RouterPort": 3030,
        "ConnectionType": 0
    }
}
```

{% api-method method="put" host="" path="/api/team/update/:code" %}
{% api-method-summary %}
Update Team parameters
{% endapi-method-summary %}

{% api-method-description %}
Use this method only to update team code parameters
{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-path-parameters %}
{% api-method-parameter name="Code" type="string" required=true %}
code of the team
{% endapi-method-parameter %}
{% endapi-method-path-parameters %}

{% api-method-body-parameters %}
{% api-method-parameter name="code" type="string" required=true %}
code of the team, \*\*can't be updated\*\*
{% endapi-method-parameter %}

{% api-method-parameter name="name" type="string" required=false %}
name of the team
{% endapi-method-parameter %}

{% api-method-parameter name="rank" type="integer" required=false %}

{% endapi-method-parameter %}

{% api-method-parameter name="winningRate" type="object" required=false %}
must be a number with floating point \(i.e. double\)
{% endapi-method-parameter %}
{% endapi-method-body-parameters %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=204 %}
{% api-method-response-example-description %}
 Identifies that the object has been updated successfully
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=404 %}
{% api-method-response-example-description %}
The code in the url is not valid or doesn't match the code in the response's body
{% endapi-method-response-example-description %}

```scheme
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|455153f7-4339c802c75bbb2e."
}
```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}

{% api-method method="put" host="" path="/api/team/config/update/:code" %}
{% api-method-summary %}
Update Team's config 
{% endapi-method-summary %}

{% api-method-description %}
Update team's routers config parameters
{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-path-parameters %}
{% api-method-parameter name="Code" type="string" required=true %}
Code of the team
{% endapi-method-parameter %}
{% endapi-method-path-parameters %}

{% api-method-body-parameters %}
{% api-method-parameter name="RouterIpAddress" type="string" required=true %}

{% endapi-method-parameter %}

{% api-method-parameter name="RouterPort" type="integer" required=true %}
must be between 1025 and 65535
{% endapi-method-parameter %}

{% api-method-parameter name="ConnectionType" type="integer" required=true %}
0: UDP \| 1: TCP
{% endapi-method-parameter %}
{% endapi-method-body-parameters %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=200 %}
{% api-method-response-example-description %}
Config has been updated and there is no error
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=400 %}
{% api-method-response-example-description %}
Router and IP are already in use or invalid
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=404 %}
{% api-method-response-example-description %}
The code is invalid
{% endapi-method-response-example-description %}

```scheme
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|455153f7-4339c802c75bbb2e."
}
```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}

{% api-method method="delete" host="" path="/api/team/delete/:code" %}
{% api-method-summary %}
Delete team
{% endapi-method-summary %}

{% api-method-description %}

{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-path-parameters %}
{% api-method-parameter name="code" type="string" required=true %}
code of the team
{% endapi-method-parameter %}
{% endapi-method-path-parameters %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=200 %}
{% api-method-response-example-description %}
Team has been deleted
{% endapi-method-response-example-description %}

```scheme
{
    "id": 7,
    "code": "KOM06",
    "name": "MRS",
    "rank": 4,
    "winningRate": 0.0,
    "configId": 7,
    "config": null,
    "gamesWon": null,
    "teamGameSummaries": null
}
```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=404 %}
{% api-method-response-example-description %}
The code is invalid
{% endapi-method-response-example-description %}

```scheme
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|455153f7-4339c802c75bbb2e."
}
```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}

{% api-method method="get" host="" path="/api/team/code/:code" %}
{% api-method-summary %}
Get team
{% endapi-method-summary %}

{% api-method-description %}

{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-path-parameters %}
{% api-method-parameter name="code" type="string" required=true %}
code of the team
{% endapi-method-parameter %}
{% endapi-method-path-parameters %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=200 %}
{% api-method-response-example-description %}

{% endapi-method-response-example-description %}

```scheme
{
    "id": 4,
    "code": "009JY",
    "name": "Rugby School2",
    "rank": 0,
    "winningRate": 0.45,
    "configId": 4,
    "config": {
        "id": 4,
        "routerIpAddress": "95.130.97",
        "routerPort": 2020,
        "connectionType": 0
    },
    "gamesWon": [],
    "teamGameSummaries": [
        {
            "id": 1,
            "teamId": 4,
            "isWinner": false,
            "score": 0,
            "numberOfPlayers": 1,
            "gameId": 1,
            "game": null
        },
        {
            "id": 3,
            "teamId": 4,
            "isWinner": false,
            "score": 0,
            "numberOfPlayers": 1,
            "gameId": 2,
            "game": null
        },
        {
            "id": 5,
            "teamId": 4,
            "isWinner": false,
            "score": 0,
            "numberOfPlayers": 1,
            "gameId": 3,
            "game": null
        },
        {
            "id": 7,
            "teamId": 4,
            "isWinner": false,
            "score": 0,
            "numberOfPlayers": 1,
            "gameId": 4,
            "game": null
        },
        {
            "id": 9,
            "teamId": 4,
            "isWinner": false,
            "score": 0,
            "numberOfPlayers": 1,
            "gameId": 5,
            "game": null
        }
    ]
}
```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=404 %}
{% api-method-response-example-description %}

{% endapi-method-response-example-description %}

```scheme
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|455153f7-4339c802c75bbb2e."
}
```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}

{% api-method method="get" host="" path="/api/team/list/:page" %}
{% api-method-summary %}
Get lists of 10 teams
{% endapi-method-summary %}

{% api-method-description %}
Return a list 10 teams according to the page number  
e.g. =&gt; page = 2 =&gt; returns second 10 teams
{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-path-parameters %}
{% api-method-parameter name="page" type="integer" required=true %}
number of a page
{% endapi-method-parameter %}
{% endapi-method-path-parameters %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=200 %}
{% api-method-response-example-description %}

{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=400 %}
{% api-method-response-example-description %}
Page number is invalid
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}

