# ProdTrack. Backend

Backend repo of the ProdTrack project.

## Ports

The port numbers for microservices are as follows:

| Microservice | Local Env         | Docker Env        | Docker Inside   |
| ------------ | ----------------- | ----------------- | --------------- |
| Catalogue    | `15000` / `15050` | `16000` / `16060` | `8080` / `8081` |

ASP.NET Core ports are listed as HTTP / HTTPS for running application.

In local development, for example, the catalog microservice will expose services on port `15000` for HTTP and `15050` for HTTPS. Once local development is complete, we'll shift to a Docker environment. In Docker, the HTTP service will be exposed on port `16000`, and HTTPS on port `16060`.

This setup remains consistent across microservices as these port numbers are specified in the Dockerfile's environment variables for any ASP.NET application. Internally, Docker will use ports `80`, `8080`, and `8081` for HTTP and HTTPS, while externally, we expose the services on ports starting from `16000` for `access`.