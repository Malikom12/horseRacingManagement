﻿namespace HorseRacingManagementSystem;

public abstract class RacingEntity
{
    public string Name { get; set; }
    public abstract string GetDetails();
}