import React from 'react';
import {
  StyleSheet,
  View,
  ScrollView,
} from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import UerWrapper from './src/components/screens/UserWrapper'; 
import UserList from './src/components/screens/UserList';

const stack = createNativeStackNavigator();

const App = () => {

  return (
    <NavigationContainer>
      <stack.Navigator>
        <stack.Screen name='Home' component={UerWrapper}></stack.Screen>
        <stack.Screen name='UserList' component={UserList}></stack.Screen>
      </stack.Navigator>
    </NavigationContainer>
  )
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff'
  }
});

export default App;
