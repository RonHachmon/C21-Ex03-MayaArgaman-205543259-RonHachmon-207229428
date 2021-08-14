using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_VehicleModel;
        private string m_LicensePlate;
        private float m_RemainingEnergy;
        private List<Wheel> r_Wheels = new List<Wheel>();

        public List<Wheel> Wheels
        {
            get
            {
                return r_Wheels;
            }


    }
}