import { createSlice } from "@reduxjs/toolkit";

const vehicleMakeSlice = createSlice({
  name: "VehicleMake",
  initialState: {
    VehicleMake: [],
  },
  reducers: {
    replaceVehicleMake(state, action) {
      state.VehicleMake = action.payload.VehicleMake;
    },
    addVehicleMake(state, action) {
      const newVehicleMake = action.payload;
      if (newVehicleMake) {
        state.VehicleMake.push({
          Id: newVehicleMake.id,
          Name: newVehicleMake.Name,
          Abrv: newVehicleMake.Abrv,
        });
      }
    },
  },
});

export const vehicleMakeActions = vehicleMakeSlice.actions;

export default vehicleMakeSlice;
