# Multi-Tenant-Authorization-Policy-Sample
This repository contains the basic code sample that demonstrates how to do a Multi-Tenant based authorization policy for any Multi-Tenant applications built for ASP.Net Core 2.0 version

## Upcoming Changes
1. There will be policies defined at the entity levels and be applied to either the controllers or to the action levels
2. There will be policies that can be configured in the form of a JSON file and then read and processed by a special handler. This way there will be more options to configure against a resource and against a URI. There will be multiple policies that will be configured and consumed by the application during runtime. This will result in a no build change for runtime policy managment or via an UI which is planned for a later period of time.
3. Many of the data is hardcoded like the users, tenants and the dummy services. In the real-time, these will be the business implementations by the development team to plug-in their developed changes or write new implementations in such a way that the services are inline with the way the application speaks Multi-Tenancy.

## Note
This is a WIP and any suggestions and implementation level guidance for any implementor will be provided. Please write to me / post as issues any changes or any discussions around development / Multi-Tenancy / Authorization Policies
