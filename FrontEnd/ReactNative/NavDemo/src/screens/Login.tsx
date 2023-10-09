import React, { useState, useRef } from 'react';
import { Button, View, StyleSheet, TextInput, TouchableOpacity, Text, Image, Alert } from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import AsyncStorage from '@react-native-async-storage/async-storage';

function LoginScreen({ navigation }) {

    
    const [getPassword, setPassword] = useState('');
    const [getEmail, setEmail] = useState('');
    const [isSecure, setIsSecure] = useState(true);

    const handleIsSecure = () => {
        setIsSecure(!isSecure)
    }

    const handleSignIn = () => {
        if (getEmail == "admin" && getPassword == "1234") {
            AsyncStorage.setItem('name', 'Vũ Tuấn');

            Alert.alert('Thông báo', `Xin chào:  ${getEmail} đã đăng nhập thành công.`, [
                { text: 'OK', onPress: () => {navigation.navigate('Home', {email: getEmail})}},
            ]);
        }else{
            Alert.alert('Thông báo', `Tài khoản của bạn là: \n Email:  ${getEmail} \n Password: ${getPassword}`, [
                { text: 'OK', onPress: () => console.log('Đăng nhập không thành công.') },
            ]);
        }
    }


    return (
        <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
            <View style={styles.formInput}>
                <TextInput style={styles.email} onChangeText={(e) => setEmail(e)} placeholder='info@petermocanu.com' />

                <TextInput style={styles.password} onChangeText={(e) => setPassword(e)} secureTextEntry={isSecure} placeholder='Enter your password' />

                <TouchableOpacity onPress={handleIsSecure} style={styles.eyePosition}>
                    <Image
                        style={styles.iconEye}
                        source={require('../../assets/image/eyeball.png')}
                    />
                </TouchableOpacity>

                <LinearGradient start={{ x: 0, y: 1 }} end={{ x: 1, y: 0 }} colors={['#3494E6', '#EC6EAD']} style={{ borderRadius: 20, marginBottom: 15 }}>
                    <TouchableOpacity onPress={handleSignIn} style={styles.btnLogin}>
                        <Text style={styles.text}>Sign In</Text>
                    </TouchableOpacity>
                </LinearGradient>
            </View>
        </View>
    );
}

const styles = StyleSheet.create({
    text: {
        textAlign: 'center',
        fontSize: 16,
        lineHeight: 18,
        fontWeight: '500',
        letterSpacing: 0.25,
        color: 'white',
    },

    btnLogin: {
        width: 150,
        paddingVertical: 12,
        paddingHorizontal: 12,
    },

    formInput: {
        alignItems: 'center',
        marginTop: 30,
        width: '80%'
    },

    email: {
        backgroundColor: '#EEEEEE',
        width: '100%',
        paddingBottom: 10,
        paddingTop: 10,
        paddingLeft: 20,
        paddingRight: 20,
        marginBottom: 20,
        borderRadius: 20,
        color: 'black'
    },

    password: {
        position: 'relative',
        backgroundColor: '#EEEEEE',
        width: '100%',
        paddingBottom: 10,
        paddingTop: 10,
        paddingLeft: 20,
        paddingRight: 20,
        marginBottom: 20,
        borderRadius: 20,
        color: 'black'
    },

    eyePosition: {
        position: 'absolute',
        top: 80,
        right: 13
    },

    iconEye: {
        width: 25,
        height: 25,

    },
})
export default LoginScreen;