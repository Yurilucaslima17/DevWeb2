export class AuthToken {
	private static token = '';

	static clearToken() {
		this.token = '';
	}

	static isAuthenticated(): boolean {
		if (this.token.length !== 0) {
			return true;
		}
		return false;
	}

	static setToken(token: string) {
		this.token = token;
	}
}
