import React, { useRef } from "react";
import { inject, observer } from "mobx-react";

const NewVehicleMake = ({ rootStore }: any) => {
    const nameInputRef = useRef<HTMLInputElement>(null);
    const abrvInputRef = useRef<HTMLInputElement>(null);

    const createVehicleMakeHandler = (() => {

        const enteredName = (nameInputRef.current as HTMLInputElement).value;
        const enteredAbrv = (abrvInputRef.current as HTMLInputElement).value;

        rootStore.vehicleMakeStore.createVehicleMakeAsync({
            name: enteredName,
            abrv: enteredAbrv,
        })
    });

    return (
        <form onSubmit={() => createVehicleMakeHandler()}>
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

export default inject("rootStore")(observer(NewVehicleMake));