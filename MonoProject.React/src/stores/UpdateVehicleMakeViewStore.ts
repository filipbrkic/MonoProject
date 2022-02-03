import { action, makeObservable, observable, runInAction } from "mobx";
import { VehicleMakeDto } from "../common/VehicleMakeDto";
import VehicleMakeService from "./VehicleMakeService"

export default class UpdateVehicleMakeViewStore {
    vehicleMakeService;
    constructor() {
        makeObservable(this, { data: observable, updateVehicleMakeAsync: action });
        this.vehicleMakeService = new VehicleMakeService();
    }

    data = [];
    status = "initial";

    updateVehicleMakeAsync = async (model: VehicleMakeDto) => {
        try {
            const response = await this.vehicleMakeService.update(model);
            if (response?.status === 200) {
                runInAction(() => {
                    this.status = "success";
                })
            }
        } catch (error) {
            runInAction(() => {
                this.status = "error"
            });
        }
    }
}