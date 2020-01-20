# Router Side API

{% api-method method="post" host="https://api.cakes.com" path="/v1a/user\_joined" %}
{% api-method-summary %}
User Joined event
{% endapi-method-summary %}

{% api-method-description %}
Call this methods when the user has joined the game
{% endapi-method-description %}

{% api-method-spec %}
{% api-method-request %}
{% api-method-body-parameters %}
{% api-method-parameter name="SchoolCode" type="string" required=false %}

{% endapi-method-parameter %}

{% api-method-parameter name="GameCode" type="string" required=false %}

{% endapi-method-parameter %}
{% endapi-method-body-parameters %}
{% endapi-method-request %}

{% api-method-response %}
{% api-method-response-example httpCode=200 %}
{% api-method-response-example-description %}
The user has successfully beed registered
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}

{% api-method-response-example httpCode=404 %}
{% api-method-response-example-description %}
The school code or the user code is invalid
{% endapi-method-response-example-description %}

```

```
{% endapi-method-response-example %}
{% endapi-method-response %}
{% endapi-method-spec %}
{% endapi-method %}



