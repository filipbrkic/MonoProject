import { useSelector } from "react-redux";

import Vehicle from "./Vehicle";
import classes from "./VehicleMake.model.css";

const DUMMY_VEHICLEMAKE = [
  { Id: "p1", Name: "BMW", Abrv: "B" },
  { Id: "p2", Name: "Audi", Abrv: "A" },
  { Id: "p3", Name: "Volvo", Abrv: "V" },
];

const VehicleMake = (props) => {
  const makeVehicles = useSelector((state) => state.make.VehicleMake);

  return (
    <section>
      <div className="title">
        <h1>Vehicles!</h1>
      </div>
      <ul>
        {DUMMY_VEHICLEMAKE.map((vehicle) => (
          <Vehicle
            key={vehicle.Id}
            Id={vehicle.Id}
            Name={vehicle.Name}
            Abrv={vehicle.Abrv}
          />
        ))}
      </ul>
    </section>
  );
};

export default VehicleMake;
