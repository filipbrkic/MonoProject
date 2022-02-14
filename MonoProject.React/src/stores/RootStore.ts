import NewVehicleMakeViewStore from "./NewVehicleMakeViewStore";
import VehicleMakeListViewStore from "./VehicleMakeListViewStore";
import UpdateVehicleMakeViewStore from "./UpdateVehicleMakeViewStore";
import DeleteVehicleMakeViewStore from "./DeleteVehicleMakeViewStore";

import VehicleOwnerListViewStore from "./VehiceOwnerListViewStore";

export default class RootStore {
    newVehicleMakeViewStore: NewVehicleMakeViewStore;
    vehicleMakeListViewStore: VehicleMakeListViewStore;
    updateVehicleMakeViewStore: UpdateVehicleMakeViewStore;
    deleteVehicleMakeViewStore: DeleteVehicleMakeViewStore;

    vehicleOwnerListViewStore: VehicleOwnerListViewStore;
    constructor() {
        this.newVehicleMakeViewStore = new NewVehicleMakeViewStore();
        this.vehicleMakeListViewStore = new VehicleMakeListViewStore();
        this.updateVehicleMakeViewStore = new UpdateVehicleMakeViewStore();
        this.deleteVehicleMakeViewStore = new DeleteVehicleMakeViewStore();

        this.vehicleOwnerListViewStore = new VehicleOwnerListViewStore();
    }
}

export const rootStore = new RootStore();