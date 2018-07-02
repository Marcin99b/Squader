<template>
    <nav>
        <ul>
            <router-link
            tag="li"
            to="/">
                SQUADER
            </router-link>
            <router-link
            tag="li"
            to="/">
                {{ 'Announcements' | translate}}
            </router-link>
            <router-link
            tag="li"
            to="/">
                {{ 'Make Squad' | translate }}
            </router-link>
            <router-link
            tag="li"
            to="/">
                {{ 'Events' | translate }}
            </router-link>
            <router-link
            tag="li"
            to="/login">
                {{ "Sign in" | translate }}
            </router-link>
            <router-link
                    tag="li"
                    to="/register">
                {{ "Sign up" | translate }}
            </router-link>
        </ul>    
    </nav>
</template>

<script>
export default {
  name: "Header",
};
</script>

<style scoped lang="scss">
</style>
