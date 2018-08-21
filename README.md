# Platform Team Challenge

Thank you for your interest in joining G Touring, and specifically being part
of the Platform Team! We're really excited to see what you can do.

## Submission

* Fork this project on Github. You will need to [install Git](https://help.github.com/articles/set-up-git/), and create an account on Github if you don't already have one.
* Complete the project as described within your fork.
* Push all of your changes to your fork on github and submit a pull request.
* We will be notified of your pull request (or feel free to email us as well), and we'll review!

If you don't wish to publicize your work on this challenge, you may simply send
the completed project in an archived file to [bartekc@gadventures.com](mailto:bartekc@gadventures.com)

## Project

This project should not take you more than 6 hours. If you require extra time to
get familiar with any documentation, please take your time. In the end, we don't
want you to feel rushed, but we also prefer you keep the scope minimal.

For this project, we prefer you use `.NET Stable 4.7.x`, and `C# Stable 7.x`.

You will be consuming an SQL Server database table which contains a series of events, delivered from our internal
applications. These events signify changes to data within our source systems, and for this exercise, we will use
a single endpoint as an example receiving client, listening to changes.

The workflow we'd like to capture is as follows:

* Every _5 seconds_, your application will read a single record from the event (`Squeak`) table. This action will be synchronous.
* For each record, you will deliver a JSON payload via `HTTP POST` to [https://webhook.site/2af5b9fd-c891-4e24-8ad0-ebb9dc3eff28](https://webhook.site/2af5b9fd-c891-4e24-8ad0-ebb9dc3eff28). The JSON payload should look as follows:

```
# The value names presented here map to the field names in the table
{
    "date_utc": UtcDate,
    "event_type": Kind,
    "resource': Topic,
    "data": {
        "id": Id
    }
}
```

* Upon successful delivery, you will update the respective record, amending the `UtcProcessedDate` field with the UTC time of when the delivery was successfully completed.
* Then, you will continue onto the next record, and continue the same set of actions.
* The application should cleanly stop processing when all 100 records in the table have been delivered.
* You can visit the [webhook site](https://webhook.site/2af5b9fd-c891-4e24-8ad0-ebb9dc3eff28]) to confirm and inspect deliveries.

Here's a sample of how the data looks like, including the unprocessed `UtcProcessedDate`:

| Id | UtcDate                 | Topic     | Kind        | UtcProcessedDate |
|----|-------------------------|-----------|-------------|------------------|
| 17 | 2018-08-21 09:00:00.000 | Time      | Minute,Hour | NULL             |
| 18 | 2018-08-21 09:00:00.000 | Booking   | Modified    | NULL             |
| 19 | 2018-08-21 09:00:01.000 | Passenger | Modified    | NULL             |
| 20 | 2018-08-21 09:00:01.000 | Invoice   | Generated   | NULL             |
| 21 | 2018-08-21 09:01:00.000 | Time      | Minute      | NULL             |
| 22 | 2018-08-21 09:01:10.000 | Booking   | Modified    | NULL             |
| 23 | 2018-08-21 09:01:12.000 | Hotel     | Modified    | NULL             |
| 24 | 2018-08-21 09:01:13.000 | Hotel     | Modified    | NULL             |
| 25 | 2018-08-21 09:01:14.000 | Hotel     | Modified    | NULL             |
| 26 | 2018-08-21 09:01:15.000 | Hotel     | Modified    | NULL             |
| 27 | 2018-08-21 09:01:30.000 | Exception | Raised      | NULL             |
| 28 | 2018-08-21 09:02:00.000 | Time      | Minute      | NULL             |
| 29 | 2018-08-21 09:02:17.000 | Hotel     | Modified    | NULL             |
| 30 | 2018-08-21 09:02:19.000 | Hotel     | Modified    | NULL             |



This application does not require a GUI, and can be a CLI. We're open to how you approach the user interface

Stylistically, we're happy you bring your own style to this challenge, and we can discuss any unique conventions afterwards. If you wish to use your
own set of tools or libraries, that is encouraged.

... And that's it! Feel free to try new technologies and patterns, as long as you're within the scope of the challenge requirements, we're happy.

## Goal

We'd like to get a sense of how you work, specifically within areas that are
unexplored territory, and if you are able to fulfill the requirements scoped
for a project.

We're looking for code that is well structured, documented, and testable. You are not expected to write unit tests, but they are a bonus.

Please provide two or so paragraphs within the `README` of how you went about
completing the challenge.

## Getting Started

The database table we've provided is hosted externally. You are expected to connect to the external host. The details are:

* Host: `SALHMHR116.THG.CO.UK`
* Username: `CandidateUser`
* Password: `Candidate123`
* Database Name: `Squeaking`
* Table Name: `Squeak`

## Talk To Us

If you have any questions, feel free to reach out to [bartekc@gadventures.com](mailto:bartekc@gadventures.com). We are looking for
candidates who are not afraid to ask questions, and explore new ideas. Asking
questions will not hurt your chances..

## Thank You!

We're excited for the opportunity to work with you. We look forward to seeing
what you create.