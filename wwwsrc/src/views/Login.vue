<template>
    <div class="login">
        <form v-if="loginForm" @submit.prevent="loginUser">
            <input type="email" v-model="creds.email" placeholder="email">
            <input type="password" v-model="creds.password" placeholder="password">
            <button type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <button type="submit">Create Account</button>
        </form>
        <div>
            <img src="../assets/KeeprLogonb.png" alt="Circle Keepr">
        </div>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">No Account? Click to Register</p>
            <p v-else>Already have an account? Click to Login</p>
        </div>
        <keeps />
    </div>
</template>

<script>
    import Keeps from "../components/Keeps.vue"
    export default {
        name: "login",
        mounted() {
            //checks for valid session
            this.$store.dispatch("authenticate");
        },
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        },
        mounted() {
            this.$store.dispatch("getAllKeeps");
        },
        components: {
            Keeps
        }
    };
</script>