using System;
using System.Collections.Generic;

public class EarningsChart
{

    public double currentQuarterEstimate { get; set; }
    public string? currentQuarterEstimateDate { get; set; }
    public string? currentCalendarQuarter { get; set; }
    public int currentQuarterEstimateYear { get; set; }
    public string? currentFiscalQuarter { get; set; }
    public List<int>? earningsDate { get; set; }
    public bool isEarningsDateEstimate { get; set; }

public override string ToString()
{
    return $"Current Quarter Estimate: {currentQuarterEstimate}";
}}