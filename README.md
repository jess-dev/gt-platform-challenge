# My Thought Process
When initially approaching the project I split it into 3 main areas:

    - Parsing the CSV
    - Converting the fields to JSON and posting the records 
    - Handling errors

For parsing the CSV I decided to reference Microsoft.VisualBasic and use the TextFieldParser, I chose this because it was something I have worked with in the past and because it was already in the .net framework, I could have brought in something like CSVHelper but I thought this was unnessecary for a small csv file. In the future if this project was to be used for something much larger another method should be used, but for the current spec TextFieldParser would do the job. Whilst parsing the CSV I create a ParsedRecord object which contains a property which is a RecordData object, all of the data from a row is put into a ParsedRecord object and then added to a list of objects to iterate over.

**Note: My first approach to this was to do the post whilst parsing the csv, so after a record is parsed it is posted off, this is what the spec sounded like it wanted me to do. I didn't like doing it like this though because it meant that my CSVInput class was also doing the posting and wasn't a good seperation of concerns. After emailing Bartek to check it was ok I then changed this so that my CSVInput just parses the csv and outputs the list of objects**

Similarly, for posting the web requests a library could also be used but the functionality for a simple post request is there in .net so I just used that. To convert the object into a JSON format I used NewtonSoft, a NuGet package which I have used before.

To handle errors I thought about what could go wrong with this program, the csv could be formatted incorrectly and the posts might not be successfull. I put try/catch blocks around code that handles those parts and print to the screen any errors that have occured. To make sure that the input is in the correct format I also made the date and id propertys DateTime and Int values

**The paths for the webhook URL and the csv files are stored in the appSettings.cs file and should be changed in there before running the program**

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

Your application will be reading a `csv` file, which contains a series of
events. These events signify changes to data within our source systems, and for this exercise, we will use
a single endpoint as an example receiving client, listening to changes.

The workflow we'd like to capture is as follows:

* Every _5 seconds_, your application will read a single row from the `squeaks.csv` file. This action will be synchronous.
* For each record, you will deliver a JSON payload via `HTTP POST` to [https://webhook.site](https://webhook.site/). You may need to create a `New URL` to POST the payload to, as the environment expires after 24 hours. The JSON payload should look as follows:

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

* Upon successful delivery, your application should:

* Continue onto the next record, and continue the same set of actions.
* The application should cleanly stop processing when the CSV has been fully read. (100 lines)
* You can visit the [webhook site](https://webhook.site/) to confirm and inspect deliveries. Make sure you visit your unique URL

Here's a sample of how the data looks like, the last column is ignored in this exercise.

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

Everything is provided in this repository, including the data you'll work with.
If you run into any blockers, please reach out! We prefer if a candidate speaks
to us.

## Talk To Us

If you have any questions, feel free to reach out to [bartekc@gadventures.com](mailto:bartekc@gadventures.com). We are looking for
candidates who are not afraid to ask questions, and explore new ideas. Asking
questions will not hurt your chances..

## Thank You!

We're excited for the opportunity to work with you. We look forward to seeing
what you create.
