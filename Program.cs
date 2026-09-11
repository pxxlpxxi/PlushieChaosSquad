using PlushieChaosSquad.Helpers;
using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Models.Incidents;
using PlushieChaosSquad.Services;
using PlushieChaosSquad.Strategies;

DispatchCenter dispatchCenter = new DispatchCenter();

ChaosIncident lowIncident = new ChaosIncident(
    "Mom's perfume has mysteriously disappeared.",
    ChaosLevel.Low);
ChaosIncident lowIncident2 =new ChaosIncident(
    "Mom's perfume has mysteriously disappeared.",
    ChaosLevel.Low);

ChaosIncident mediumIncident = new ChaosIncident(
    "Dad's entire toolbox has been rearranged.",
    ChaosLevel.Medium);
ChaosIncident mediumIncident2 = new ChaosIncident(
    "Dad's entire toolbox has been rearranged.",
    ChaosLevel.Medium);

ChaosIncident highIncident = new ChaosIncident(
    "The living room has become a complete disaster.",
    ChaosLevel.High);
ChaosIncident highIncident2 = new ChaosIncident(
    "The living room has become a complete disaster.",
    ChaosLevel.High);

dispatchCenter.AddIncident(lowIncident);
dispatchCenter.AddIncident(lowIncident2);

dispatchCenter.AddIncident(mediumIncident);
dispatchCenter.AddIncident(mediumIncident2);

dispatchCenter.AddIncident(highIncident);
dispatchCenter.AddIncident(highIncident2);


IDispatchStrategy strategy = new FirstAvailableStrategy();
IDispatchStrategy strategy2 = new StrongestPlushieStrategy();


//low Level Incident

string lowReport = dispatchCenter.HandleIncident(
        lowIncident,
        strategy,
        incident => incident.MarkAsResolved());
UIReport.WriteReport(
    "LOW LEVEL INCIDENT - FIRST AVAILABLE STRATEGY",
    lowReport,
    lowIncident.IsResolved);

string lowReport2 = dispatchCenter.HandleIncident(
    lowIncident2,
    strategy2,
    incident => incident.MarkAsResolved());
UIReport.WriteReport(
    "LOW LEVEL INCIDENT - STRONGEST PLUSHIE STRATEGY",
    lowReport2,
    lowIncident2.IsResolved);

    Console.WriteLine();
//Medium Level Incident

string mediumReport = dispatchCenter.HandleIncident(
        mediumIncident,
        strategy,
        incident => incident.MarkAsResolved());
UIReport.WriteReport(
    "MEDIUM LEVEL INCIDENT - FIRST AVAILABLE STRATEGY",
    mediumReport,
    mediumIncident.IsResolved);

Console.WriteLine();

string mediumReport2 = dispatchCenter.HandleIncident(
        mediumIncident2,
        strategy2,
        incident => incident.MarkAsResolved());
UIReport.WriteReport(
    "MEDIUM LEVEL INCIDENT - STRONGEST PLUSHIE STRATEGY ",
    mediumReport2,
    mediumIncident2.IsResolved);

Console.WriteLine();

//High Level Incident

string highReport = dispatchCenter.HandleIncident(
    highIncident,
    strategy,
    incident => incident.MarkAsResolved());
UIReport.WriteReport(
    "HIGH LEVEL INCIDENT - FIRST AVAILABLE STRATEGY",
    highReport,
    highIncident.IsResolved);

string highReport2 = dispatchCenter.HandleIncident(
    highIncident2,
    strategy2,
    incident => incident.MarkAsResolved());
UIReport.WriteReport(
    "HIGH LEVEL INCIDENT - STRONGEST PLUSHIE STRATEGY",
    highReport2,
    highIncident2.IsResolved);

Console.WriteLine();

await dispatchCenter.WreakHavocAsync();

Console.ReadKey();
