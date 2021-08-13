using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_VehicleModel;
        protected string m_LicensePlate;
        protected float m_RemainingEnergy;
        protected readonly List<Wheel> r_Wheels = new List<Wheel>();


    }
}