import { action, makeObservable, observable, runInAction } from "mobx";
import { VehicleMakeDto } from "../common/VehicleMakeDto";
import VehicleMakeService from "./VehicleMakeService"

export default class DeleteVehicleMakeViewStore {
    vehicleMakeService: VehicleMakeService;
    constructor() {
        makeObservable(this, { data: observable, deleteCountryAsync: action });
        this.vehicleMakeService = new VehicleMakeService();
    }

    data = [];
    status = "initial";

    deleteCountryAsync = async (id: number) => {
        try {
            const response = await this.vehicleMakeService.delete(id);
            if (response?.status === 204) {
                runInAction(() => {
                    this.status = "success";
                })
            }
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            });
        }
    }
}