# OutputCacheIssue

This repo shows a racing condition issue with output cache that happens when one of the racing 
requests is canceled by the client. When it happens the output cache middleware returns an empty response.

## To reproduce

1. Start the server web api

2. Run the console app - usually on the first 3 attemps we can observe the response body returning empty.