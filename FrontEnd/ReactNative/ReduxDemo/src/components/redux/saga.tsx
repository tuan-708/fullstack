import { takeEvery, put} from 'redux-saga/effects';
import { USER_LIST , SET_USER_DATA} from './constrants';

function* UserList(): any{
    const url = "https://jsonplaceholder.typicode.com/posts"
    let data = yield fetch(url);
    data = yield data.json();
    yield put({type: SET_USER_DATA, data})

}

function* SagaData(){
    yield takeEvery(USER_LIST, UserList);
}

export default SagaData;