import { makeAutoObservable, runInAction } from "mobx";
import { post, getAll } from "./VehicleMakeService";

class VehicleMakeStore {
    constructor() {
        makeAutoObservable(this);
    }
    model = [];

    status = "initial";

    createVehicleMakeAsync = async (model) => {
        try {
            const response = await post(model);
            if (response.status === 200) {
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
    };

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
    };
}

export default new VehicleMakeStore();