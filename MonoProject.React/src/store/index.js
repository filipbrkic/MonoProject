import { configureStore } from "@reduxjs/toolkit";

import vehicleMakeSlice from "./vehicleMake-slice";

const store = configureStore({
  reducer: { make: vehicleMakeSlice.reducer },
});

export default store;
