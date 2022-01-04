import React, { useRef } from "react";
import { inject, observer, PropTypes } from "mobx-react";
import VehicleMakeStore from "../stores/VehicleMakeStore";

const NewVehicleMake = (props) => {
    const nameInputRef = useRef(null);
    const abrvInputRef = useRef(null);

    const createVehicleMakeHandler = (() => {

        const enteredName = nameInputRef.current.value;
        const enteredAbrv = abrvInputRef.current.value;

        props.store.createVehicleMakeAsync({
            id: null,
            name: enteredName,
            abrv: enteredAbrv
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

export default inject("store")(observer(NewVehicleMake));