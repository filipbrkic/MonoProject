import VehicleMakeStore from "./VehicleMakeStore";

export default class RootStore {
    vehicleMakeStore;
    constructor() {
        this.vehicleMakeStore = new VehicleMakeStore(this);
    }
}

export const rootStore = new RootStore();