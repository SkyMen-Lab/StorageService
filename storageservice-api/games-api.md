# Games API

{% api-method method="post" host="https://api.cakes.com" path="/api/game/create/" %}
{% api-method-summary %}
Set up a game
{% endapi-method-summary %}

{% api-method-description %}
Send json file with all game configuration
{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-headers %}
{% api-method-parameter name="Authentication" type="string" required=true %}
Authentication token to track down who is emptying our stocks.
{% endapi-method-parameter %}
{% endapi-method-headers %}

{% api-method-body-parameters %}
{% api-method-parameter name="FirstTeamCode" type="string" required=true %}
Code of the first team
{% endapi-method-parameter %}

{% api-method-parameter name="SecondTeamCode" type="string" required=true %}
Code of the second team
{% endapi-method-parameter %}

{% api-method-parameter name="Date" type="string" required=true %}
Approximate date of the match
{% endapi-method-parameter %}

{% api-method-parameter name="DurationMinutes" type="integer" required=true %}
The duration of the game in minutes
{% endapi-method-parameter %}

{% api-method-parameter name="CreatedBy" type="string" required=false %}
Name of the use setting up the game
{% endapi-method-parameter %}
{% endapi-method-body-parameters %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=201 %}
{% api-method-response-example-description %}
Cake successfully retrieved.
{% endapi-method-response-example-description %}

```scheme
{
    "id": 2,
    "code": "RA162",
    "state": 0,
    "teamGameSummaries": [
        {
            "id": 3,
            "teamId": 4,
            "team": {
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
                    }
                ]
            },
            "isWinner": false,
            "score": 0,
            "numberOfPlayers": 1,
            "gameId": 2
        },
        {
            "id": 4,
            "teamId": 5,
            "team": {
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
                "gamesWon": [],
                "teamGameSummaries": [
                    {
                        "id": 2,
                        "teamId": 5,
                        "isWinner": false,
                        "score": 0,
                        "numberOfPlayers": 1,
                        "gameId": 1,
                        "game": null
                    }
                ]
            },
            "isWinner": false,
            "score": 0,
            "numberOfPlayers": 1,
            "gameId": 2
        }
    ],
    "winnerCode": "None",
    "date": "2020-02-01T23:28:56.782Z",
    "durationMinutes": 10,
    "createdBy": "SkymanOne"
}
```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=400 %}
{% api-method-response-example-description %}
Could not find a cake matching this query.
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

{% api-method method="get" host="" path="/api/game/:code" %}
{% api-method-summary %}
Get the game data
{% endapi-method-summary %}

{% api-method-description %}

{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-path-parameters %}
{% api-method-parameter name="code" type="string" required=true %}
Code of the game
{% endapi-method-parameter %}
{% endapi-method-path-parameters %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=200 %}
{% api-method-response-example-description %}

{% endapi-method-response-example-description %}

```scheme
{
  "id": 1,
  "code": "92Q2J",
  "state": 1,
  "teamGameSummaries": [
    {
      "id": 1,
      "teamId": 4,
      "team": null,
      "isWinner": false,
      "score": 0,
      "numberOfPlayers": 1,
      "gameId": 1
    },
    {
      "id": 2,
      "teamId": 5,
      "team": null,
      "isWinner": false,
      "score": 0,
      "numberOfPlayers": 1,
      "gameId": 1
    }
  ],
  "winnerCode": "Nobody",
  "date": "2020-01-01T23:28:56.782",
  "durationMinutes": 10,
  "createdBy": "SkymanOne"
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
  "traceId": "|e319a014-445977679b4cc8f3."
}
```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}

{% api-method method="get" host="" path="/api/game/list/:page" %}
{% api-method-summary %}
Get list of 10 games
{% endapi-method-summary %}

{% api-method-description %}
return a list of 10 games according to the page number  
e.g. =&gt; page = 2 =&gt; return second 10 games' records
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
returns a list of 10 games
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=400 %}
{% api-method-response-example-description %}
page number is invalid
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}

{% api-method method="post" host="" path="/api/game/start" %}
{% api-method-summary %}
Start game
{% endapi-method-summary %}

{% api-method-description %}
Start the game with given configuration
{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-body-parameters %}
{% api-method-parameter name="code" type="string" required=true %}
code of the game
{% endapi-method-parameter %}
{% endapi-method-body-parameters %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=200 %}
{% api-method-response-example-description %}
The game has been started successfully 
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=404 %}
{% api-method-response-example-description %}
game has not been found
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=500 %}
{% api-method-response-example-description %}
error with GameService
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}

