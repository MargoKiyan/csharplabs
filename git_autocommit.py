from os import system as g
from os import path as t
import sys


def check_gitignore_acm():
    if not t.exists(".gitignore"):
        return False
    try:
        with open(".gitignore", "r") as i:
            for line in i:
                if line.strip() == ".acm":
                    return True
        return False
    except:
        return False


def check_gitignore_itself():
    if not t.exists(".gitignore"):
        return False
    try:
        with open(".gitignore", "r") as i:
            for line in i:
                if line.strip() == "git_autocommit.py":
                    return True
        return False
    except:
        return False


def save_params():
    remote_name = input("Enter your remote name (blank for \"origin\"): ").strip()
    branch_name = input("Enter your branch name (blank for \"main\"): ").strip()

    remote_name = remote_name if remote_name else "origin"
    branch_name = branch_name if branch_name else "main"

    with open(".acm", "w") as j:
        j.write(f"remote_name={remote_name}\n")
        j.write(f"branch_name={branch_name}\n")
    print(f"Parameters saved: remote='{remote_name}', branch='{branch_name}'")

    add_to_ignore = input("Should parameters be added to gitignore? (yes/no): ")
    if add_to_ignore == "yes" or add_to_ignore == "y":
        if not check_gitignore_acm():
            with open(".gitignore", "a") as i:
                i.write(f"\n.acm\n")

            print(f"File .acm was added to gitignore")
        else:
            print("Nothing changed. File .acm is already in gitignore")

    else:
        print(f"Kept gitignore unchanged")

    return remote_name, branch_name


def load_params(force_reset=False):
    if force_reset or not t.exists(".acm"):
        if force_reset:
            print("Force reset requested. Setting new parameters...")
        else:
            print("File .acm not found. You should manually set parameters below")
        return save_params()

    if not check_gitignore_itself():
        with open(".gitignore", "a") as i:
            i.write(f"\ngit_autocommit.py\n")

    remote_name = None
    branch_name = None

    try:
        with open(".acm", "r") as j:
            for line in j:
                if line.startswith("remote_name="):
                    remote_name = line.split("=")[1].strip()
                elif line.startswith("branch_name="):
                    branch_name = line.split("=")[1].strip()
    except:
        return save_params()

    if remote_name and branch_name:
        return remote_name, branch_name
    else:
        print("Parameters was corrupted. You should reset parameters below")
        return save_params()

try:
    force_reset = "--reset" in sys.argv or "-r" in sys.argv


    remote_name, branch_name = load_params(force_reset=force_reset)

    commit_message = input("Enter commit message (blank for \"autocommit\"): ").strip()
    commit_message = commit_message if commit_message else "autocommit"

    g("git add .")
    g(f"git commit -m \"{commit_message}\"")
    g(f"git push -u {remote_name} {branch_name}")
except Exception as e:
    print(f"Error: {e}")
    exit(1)