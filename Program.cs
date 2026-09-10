using PlushieChaosSquad.Helpers;
using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Models.Incidents;
using PlushieChaosSquad.Models.Moves;
using PlushieChaosSquad.Models.Squad;
using PlushieChaosSquad.Services;
using PlushieChaosSquad.Strategies;



DispatchCenter dispatchCenter = new DispatchCenter();

ChaosIncident lowIncident = new ChaosIncident(
        "Mom's perfume has mysteriously disappeared.",
        ChaosLevel.Low);

    ChaosIncident mediumIncident = new ChaosIncident(
        "Dad's entire toolbox has been rearranged.",
        ChaosLevel.Medium);

    ChaosIncident highIncident = new ChaosIncident(
        "The living room has become a complete disaster.",
        ChaosLevel.High);

    dispatchCenter.AddIncident(lowIncident);
    dispatchCenter.AddIncident(mediumIncident);
    dispatchCenter.AddIncident(highIncident);

    IDispatchStrategy strategy = new FirstAvailableStrategy();

//low Level Incident

string lowReport = dispatchCenter.HandleIncident(
        lowIncident,
        strategy,
        incident => incident.MarkAsResolved());

    UIReport.WriteReport(
        "LOW LEVEL INCIDENT",
        lowReport,
        lowIncident.IsResolved);

    Console.WriteLine();
//Medium Level Incident

string mediumReport = dispatchCenter.HandleIncident(
        mediumIncident,
        strategy,
        incident => incident.MarkAsResolved());

    UIReport.WriteReport(
        "MEDIUM LEVEL INCIDENT",
        mediumReport,
        mediumIncident.IsResolved);

    Console.WriteLine();

    IDispatchStrategy strategy2 = new StrongestPlushieStrategy();

    //High Level Incident

    string highReport = dispatchCenter.HandleIncident(
        highIncident,
        strategy2,
        incident => incident.MarkAsResolved());

    UIReport.WriteReport(
        "HIGH LEVEL INCIDENT",
        highReport,
        highIncident.IsResolved);

    Console.WriteLine();

await dispatchCenter.WreakHavoc();

Console.ReadKey();
