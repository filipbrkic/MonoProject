import { useDispatch } from "react-redux";

import { vehicleMakeActions } from "../store/vehicleMake-slice";
import classes from "./Vehicle.model.css";

const Vehicle = (props) => {
  const dispatch = useDispatch();

  const { Name, Abrv, Id } = props;

  const addVehicleMakeHandler = () => {
    dispatch(
      vehicleMakeActions.addVehicleMake({
        Id,
        Name,
        Abrv,
      })
    );
  };

  return (
    <li className="name">
      <h1>{Name}</h1>
      <div className="abrv">
        <span>Abrv: {Abrv}</span>
      </div>
      <button className="btn" onClick={addVehicleMakeHandler}>
        Add Vehicle Make
      </button>
    </li>
  );
};

export default Vehicle;
