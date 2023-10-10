import { ADD_TO_CART, REMOVE_TO_CART, SET_USER_DATA, USER_LIST } from "./constrants";
const initialState: any = [];

function removeObjectWithId(arr:any, id:any) {
    // Making a copy with the Array from() method
    const arrCopy = Array.from(arr);
  
    const objWithIdIndex = arrCopy.findIndex((obj:any) => obj.id === id);
    arrCopy.splice(objWithIdIndex, 1);
    return arrCopy;
  }

export const reducer=(state=initialState, action:any)=>{
    switch(action.type){
        case ADD_TO_CART:
            return [
                ...state,
                action.data
            ]
        case REMOVE_TO_CART:
            var current = removeObjectWithId(state, action.id)
            return current;
        case SET_USER_DATA:
            return [...state,action.data]
        default:
            return state;
    }
}