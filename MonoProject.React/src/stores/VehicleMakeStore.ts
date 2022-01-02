import { action, makeObservable, observable, runInAction } from "mobx";
import { VehicleMakeDto } from "../common/VehicleMakeDto";
import VehicleMakeService from "./VehicleMakeService";

class VehicleMakeStore {
    vehicleMakeData = {
        model: []
    };
    status = "initial";
    constructor() {
        makeObservable(this, { vehicleMakeData: observable, createVehicleMakeAsync: action });
    }

    createVehicleMakeAsync = async (model: VehicleMakeDto) => {
        try {
            const response = await VehicleMakeService.post(model);
            if (response.status === 200) {
                runInAction(() => {
                    this.status = "success";
                })
            }
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            })
        }
    }
}

export default new VehicleMakeStore();