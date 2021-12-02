import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";

import VehicleMake from "./components/VehicleMake";
import {
  sendVehicleMakeData,
  fetchVehicleMakeData,
} from "./store/vehicleMake-actions";

let isInitial = true;

function App() {
  const dispatch = useDispatch();
  const vehicleMake = useSelector((state) => state.make);

  /* useEffect(() => {
    dispatch(fetchVehicleMakeData());
  }, [dispatch]);*/

  useEffect(() => {
    if (isInitial) {
      isInitial = false;
      return;
    }

    dispatch(sendVehicleMakeData(vehicleMake));
  }, [vehicleMake, dispatch]);

  return <VehicleMake />;
}

export default App;
