import { action, makeObservable, observable, runInAction } from "mobx";
import { VehicleMakeDto } from "../common/VehicleMakeDto";
import { post, getAll } from "./VehicleMakeService";

class VehicleMakeStore {
    vehicleMakeData = {
        model: [],
    };
    status = "initial";
    constructor() {
        makeObservable(this, { vehicleMakeData: observable, createVehicleMakeAsync: action });
    }

    createVehicleMakeAsync = async (model: VehicleMakeDto) => {
        try {
            const response = await post(model);
            if (response !== undefined && response.status === 200) {
                runInAction(() => {
                    this.status = "success";
                })
            }
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.status = "error";
            })
        }
    }

    getAllVehicleMakeAsync = async () => {
        try {
            const data = await getAll();
            runInAction(() => {
                this.vehicleMakeData = data;
            })
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            })
        }
    }
}

export default new VehicleMakeStore();

function params(params: any) {
    throw new Error("Function not implemented.");
}
