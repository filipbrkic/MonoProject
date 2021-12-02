import { vehicleMakeActions } from "./vehicleMake-slice";

/*export const fetchVehicleMakeData = () => {
  return async (dispatch) => {
    const fetchData = async () => {
      const response = await fetch(
        "https://react-http-8be08-default-rtdb.europe-west1.firebasedatabase.app/vehiclemake.json"
      );

      if (!response.ok) {
        throw new Error("Fetching data failed!");
      }

      const data = await response.json();

      return data;
    };

    try {
      const makeData = await fetchData();
      dispatch(vehicleMakeActions.replaceVehicleMake(makeData));
    } catch (error) {
      throw new Error("Fetching data failed!");
    }
  };
};*/

export const sendVehicleMakeData = (make) => {
  return async (dispatch) => {
    const sendRequest = async () => {
      const response = await fetch(
        "https://react-http-8be08-default-rtdb.europe-west1.firebasedatabase.app/vehiclemake.json",
        { method: "POST", body: JSON.stringify(make) }
      );

      if (!response.ok) {
        throw new Error("Sending data failed!");
      }
    };

    try {
      await sendRequest();
    } catch (error) {
      throw new Error("Sending data failed!");
    }
  };
};
