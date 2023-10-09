import { ADD_TO_CART, REMOVE_TO_CART } from "./constrants";

export function addToCart(item: any){
    return{
        type: ADD_TO_CART,
        data: item
    }
}

export function removeToCart(item: any){
    return{
        type: REMOVE_TO_CART,
        data: item
    }
}