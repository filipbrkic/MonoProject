import VehicleMakeStore from "./VehicleMakeStore";
import VehicleOwnerStore from "./VehicleOwnerStore";

export default class RootStore {
    vehicleMakeStore;
    vehicleOwnerStore;
    constructor() {
        this.vehicleMakeStore = new VehicleMakeStore();
        this.vehicleOwnerStore = new VehicleOwnerStore();
    }
}

export const rootStore = new RootStore();