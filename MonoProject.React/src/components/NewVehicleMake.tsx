import React, { useRef } from "react";
import { inject, observer } from "mobx-react";
import VehicleMakeStore from "../stores/VehicleMakeStore";
import { VehicleMakeDto } from "../common/VehicleMakeDto";

const NewVehicleMake: React.FC = (props: any) => {
    const nameInputRef = useRef<HTMLInputElement>(null);
    const abrvInputRef = useRef<HTMLInputElement>(null);

    const createVehicleMakeHandler = ((e: React.FormEvent<HTMLFormElement>) => (VehicleMakeDto: { id: number, name: string, abrv: string }) => {
        e.preventDefault();

        const enteredName = (nameInputRef.current as HTMLInputElement).value;
        const enteredAbrv = (abrvInputRef.current as HTMLInputElement).value;

        props.VehicleMakeStore.createVehicleMakeAsync({
            id: VehicleMakeDto.id,
            name: enteredName,
            abrv: enteredAbrv,
        })
    });

    return (
        <form onSubmit={createVehicleMakeHandler}>
            <div>
                <input id="name" type="text" placeholder="Name" ref={nameInputRef} />
            </div>
            <div>
                <input id="abrv" type="text" placeholder="Abbreviation" ref={abrvInputRef} />
            </div>
            <button type="submit" >Save</button>
        </form>
    );
}

export default inject("store")(observer(NewVehicleMake));